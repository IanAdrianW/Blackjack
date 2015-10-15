﻿using System;
using System.Collections.Generic;

namespace Blackjack.src
{
	public class Hand
	{
		public List<Card> Cards = new List<Card>();
		private int Total;

		public Hand ()
		{
		}

		public int CardTotal 
		{
			get 
			{
				int Total = 0;
				foreach (Card card in Cards)
				{
					Total += (int)card.CardRank;
				}
				return Total;
			}

			set 
			{ 
				Total = value;
			}


		}

		public void AddCard (Card card)
		{
			Cards.Add (card);
		}



	}
}
