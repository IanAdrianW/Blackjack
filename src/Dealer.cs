﻿using System;
using SwinGameSDK;

namespace Blackjack.src
{
	public class Dealer : Hand
	{
		public Dealer ()
		{
		}
			
		public void Deal (Deck deck)
		{
			while (CardTotal < 17)
			{
				AddCard (deck.Draw());
			}
		}

		public override void DrawFirstTwoCards ()
		{
			Card FirstCard = Cards [0];
			SwinGame.DrawBitmap(FirstCard.CardImage(), 400f, 75f);
		}
	}
}