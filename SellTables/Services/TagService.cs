﻿using SellTables.Interfaces;
using SellTables.Models;
using SellTables.Repositories;
using SellTables.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellTables.Services
{
    public class TagService
    {
        private IRepository<Tag> Repository;
        private ApplicationDbContext dataBaseContext;

        public TagService(ApplicationDbContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
            Repository = new TagsRepository(dataBaseContext);
        }

        public List<Tag> GetAllTags()
        {
            var listOfTags = (Repository.GetAll());
            return listOfTags.ToList();
        }

        public List<TagViewModel> GetAllModelTags()
        {
            var listOfTags = InitTagModel(Repository.GetAll());
            return listOfTags.ToList();
        }

        public ICollection<string> GetMostPopularTags(int number = 20)
        {
            var mostPopular = new int[number];
            var result = new string[number];
            if (GetAllTags() == null)
                return result.ToList();
            foreach (Tag tag in GetAllTags())
                for (int i = 0; i < number; i++)
                {
                    var newTagRepeats = GetTagRepeatNumber(tag);
                    if (result.Contains(null))
                    {
                        var index = Array.IndexOf(result, null);
                        result[index] = tag.Description;
                        mostPopular[index] = newTagRepeats;
                        break;
                    }
                    if (newTagRepeats > mostPopular[i])
                    {
                        mostPopular[i] = newTagRepeats;
                        result[i] = tag.Description;
                        break;
                    }
                }
            return result.ToList();
        }


        private static ICollection<Tag> GetTags(string tagList)
        {
            var stringList = tagList.Split(' ');
            var tags = new List<Tag>();
            if (stringList != null)
            {
                foreach (string text in stringList)
                    tags.Add(new Tag() { Description = text });
            }
            return tags;
        }

        private int GetTagRepeatNumber(Tag tag)
        {
            if (tag == null || FindTag(tag.Description) == null)
                return 0;
            var findTag = FindTag(tag.Description);
            return findTag.Chapters.Count;
        }

        private Tag FindTag(string name)
        {
            return dataBaseContext.Tags
                    .Where(t => t.Description == name)
                    .FirstOrDefault();
        }

        private ICollection<TagViewModel> InitTagModel(ICollection<Tag> list)
        {
            return list.Select(tag => new TagViewModel
            {
                Id = tag.Id,
                Description = tag.Description
            }).ToList();
        }

    }
}