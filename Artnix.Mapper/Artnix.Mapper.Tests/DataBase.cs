﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artnix.Mapper.Tests.Mock.Models;

namespace Artnix.Mapper.Tests
{
    internal static class DataBase
    {
        static DataBase()
        {
            const int count = 100;
            OnCreateCities(count);
            OnCreateStudentss(count);
        }

        public static List<StudentModelMock> Students { get; private set; }

        public static List<CityModelMock> Cities { get; private set; }

        public static void Init() { }

        private static void OnCreateStudentss(int count)
        {
            Students = new List<StudentModelMock>(count);
            var rnd = new Random();
            int percent = 2 + (count * 10 / 100);
            for (int i = 1; i <= count; i++)
            {
                string name = "Name" + i;
                int? cityId = GetNullableId(rnd, percent, 1, 100);
                CityModelMock cityModel = null;
                if (cityId != null)
                    cityModel = Cities.FirstOrDefault(p => p.Id == cityId);

                var item = new StudentModelMock
                {
                    Id = i,
                    Name = name,
                    Family = "Family" + i,
                    Email = name + "@mail.com",
                    City = cityId,
                    Createdate = DateTime.Now.AddDays(rnd.Next(-366, 366)),
                    CityModel = cityModel
                };

                Students.Add(item);
            }
        }

        private static void OnCreateCities(int count)
        {
            Cities = new List<CityModelMock>(count);
            var rnd = new Random();
            int percent = 2 + (count * 10 / 100);
            for (int i = 1; i <= count; i++)
            {
                var item = new CityModelMock
                {
                    Id = i,
                    Name = "Name" + i,
                    CreateDate = DateTime.Now.AddDays(rnd.Next(-366, 366)),
                    DestroyDate = null,
                    Latitude = rnd.Next(516400146, 630304598),
                    Longitude = rnd.Next(224464416, 341194152),
                    Region = GetNullableId(rnd, percent, 1, 100)
                };

                Cities.Add(item);
            }
        }

        private static int? GetNullableId(Random rnd, int nullableRange, int start, int end)
        {
            if (rnd.Next(0, nullableRange) == 0)
                return null;
            return rnd.Next(start, end);
        }
    }
}