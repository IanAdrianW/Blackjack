﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Blackjack.src.tests
{
    [TestFixture()]
    class TestCard
    {
        [Test()]
        public void TestDealCard()
        {
            Deck deck = new Deck();
            Hand hand = new Hand();
			Assert.IsTrue(deck.CardsLeft() == 52);
            deck.Draw();
			Assert.IsTrue(deck.CardsLeft() == 51);
        }

        [Test()]
        public void TestHandTotal()
        {
            Deck deck = new Deck();
            Hand hand = new Hand();
            Assert.IsTrue(hand.Cards.Count == 0);
            hand.AddCard(deck.Draw());
            Assert.IsTrue(hand.Cards.Count == 1);
        }

        [Test()]
        public void TestCardTotal()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.SEVEN, Suit.SPADE));
            hand.AddCard(new Card(Rank.JACK, Suit.SPADE));
            Assert.IsTrue(hand.CardTotal == 17);
        }

        [Test()]
        public void TestCardTotalWithHighAce()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.ACE, Suit.SPADE));
            hand.AddCard(new Card(Rank.JACK, Suit.SPADE));
			Assert.IsTrue(hand.CardTotal == 21);
        }

        [Test()]
        public void TestCardTotalWithLowAce()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.NINE, Suit.SPADE));
            hand.AddCard(new Card(Rank.JACK, Suit.SPADE));
            hand.AddCard(new Card(Rank.ACE, Suit.SPADE));
			Assert.IsTrue(hand.CardTotal == 20);
        }

        [Test()]
        public void TestDealer15()
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            dealer.AddCard(new Card(Rank.KING, Suit.HEART));
            dealer.AddCard(new Card(Rank.FIVE, Suit.CLUB));
			dealer.Deal(deck);
            Assert.IsTrue(dealer.Cards.Count == 3);
        }

        [Test()]
        public void TestDealer16()
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            dealer.AddCard(new Card(Rank.KING, Suit.HEART));
            dealer.AddCard(new Card(Rank.SIX, Suit.CLUB));
			dealer.Deal(deck);
            Assert.IsTrue(dealer.Cards.Count == 2);
        }

        [Test()]
        public void TestWin()
        {
            Hand player = new Hand();
            Dealer dealer = new Dealer();
            player.AddCard(new Card(Rank.TEN, Suit.DIAMOND));
            player.AddCard(new Card(Rank.TEN, Suit.SPADE));

            dealer.AddCard(new Card(Rank.TEN, Suit.CLUB));
            dealer.AddCard(new Card(Rank.NINE, Suit.SPADE));

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
            game.CheckScores();

            Assert.IsTrue(game.State == GameState.PLAYER_WINS);
        }

        [Test()]
        public void TestDraw()
        {
            Hand player = new Hand();
            Dealer dealer = new Dealer();
            player.AddCard(new Card(Rank.TEN, Suit.DIAMOND));
            player.AddCard(new Card(Rank.TEN, Suit.SPADE));

            dealer.AddCard(new Card(Rank.TEN, Suit.CLUB));
            dealer.AddCard(new Card(Rank.TEN, Suit.HEART));

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
            game.CheckScores();

            Assert.IsTrue(game.State == GameState.DRAW);
        }

        [Test()]
        public void TestLose()
        {
            Hand player = new Hand();
            Dealer dealer = new Dealer();
            player.AddCard(new Card(Rank.NINE, Suit.DIAMOND));
            player.AddCard(new Card(Rank.TEN, Suit.SPADE));

            dealer.AddCard(new Card(Rank.TEN, Suit.CLUB));
            dealer.AddCard(new Card(Rank.TEN, Suit.HEART));

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
            game.CheckScores();

            Assert.IsTrue(game.State == GameState.PLAYER_LOSE);
        }

        [Test()]
        public void TestBust()
        {
            Hand player = new Hand();
            Dealer dealer = new Dealer();
            player.AddCard(new Card(Rank.NINE, Suit.DIAMOND));
            player.AddCard(new Card(Rank.TEN, Suit.SPADE));
            player.AddCard(new Card(Rank.FIVE, Suit.SPADE));

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
            game.CheckScores();

            Assert.IsTrue(game.State == GameState.PLAYER_LOSE);
        }
    }
}
