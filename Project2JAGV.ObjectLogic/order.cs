﻿using System;

namespace Project2JAGV.ObjectLogic
{
    public class order
    {
        private int _id;
        private int _userId;
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must not be negative");
                }

                _id = value;
            }
        }
        public int UserId
        {
            get => _userId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("User Id must not be negative");
                }

                _userId = value;
            }
        }
        public DateTime Date { get; set; }
    }
}