﻿using ConsoleGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public static class EnqueueClass
    {
        public static void Enqueue(this Queue<Card> cards, Queue<Card> newCards)
        {
            foreach(var card in newCards)
            {
                cards.Enqueue(card);
            }
        }    
        
    }
}
