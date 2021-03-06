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
            Player hand = new Player();
			Assert.IsTrue(deck.CardsLeft() == 52);
            deck.Draw();
			Assert.IsTrue(deck.CardsLeft() == 51);
        }

        [Test()]
        public void TestPlayerTotal()
        {
            Deck deck = new Deck();
            Player hand = new Player();
            Assert.IsTrue(hand.Cards.Count == 0);
            hand.AddCard(deck.Draw());
            Assert.IsTrue(hand.Cards.Count == 1);
        }

        [Test()]
        public void TestCardTotal()
        {
            Player hand = new Player();
            hand.AddCard(new Card(Rank.SEVEN, Suit.SPADE));
            hand.AddCard(new Card(Rank.JACK, Suit.SPADE));
            Assert.IsTrue(hand.CardTotal == 17);
        }

        [Test()]
        public void TestCardTotalWithHighAce()
        {
            Player hand = new Player();
            hand.AddCard(new Card(Rank.ACE, Suit.SPADE));
            hand.AddCard(new Card(Rank.JACK, Suit.SPADE));
			Assert.IsTrue(hand.CardTotal == 21);
        }

        [Test()]
        public void TestCardTotalWithLowAce()
        {
            Player hand = new Player();
            hand.AddCard(new Card(Rank.NINE, Suit.SPADE));
            hand.AddCard(new Card(Rank.JACK, Suit.SPADE));
            hand.AddCard(new Card(Rank.ACE, Suit.SPADE));
			Assert.IsTrue(hand.CardTotal == 20);
        }

        [Test()]
        public void TestDealer16()
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            dealer.AddCard(new Card(Rank.KING, Suit.HEART));
            dealer.AddCard(new Card(Rank.SIX, Suit.CLUB));
			dealer.Deal (deck);
			Assert.IsTrue (dealer.CardsinHand == 3);
        }

        [Test()]
        public void TestDealer17()
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            dealer.AddCard(new Card(Rank.KING, Suit.HEART));
            dealer.AddCard(new Card(Rank.SEVEN, Suit.CLUB));
			dealer.Deal(deck);
			Assert.IsTrue (dealer.CardsinHand == 2);
        }

        [Test()]
        public void TestWin()
        {
            Player player = new Player();
            Dealer dealer = new Dealer();
            Deck deck = new Deck();
            player.AddCard(new Card(Rank.TEN, Suit.DIAMOND));
            player.AddCard(new Card(Rank.TEN, Suit.SPADE));


            dealer.AddCard(new Card(Rank.TEN, Suit.CLUB));
            dealer.AddCard(new Card(Rank.NINE, Suit.SPADE));

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
			game.Decision = true;
            game.CheckScores();

            Assert.IsTrue(game.Status == GameState.WIN);
        }

        [Test()]
        public void TestDraw()
        {
            Player player = new Player();
            Dealer dealer = new Dealer();
            Deck deck = new Deck();
            player.AddCard(new Card(Rank.TEN, Suit.DIAMOND));
            player.AddCard(new Card(Rank.TEN, Suit.SPADE));

            dealer.AddCard(new Card(Rank.TEN, Suit.CLUB));
            dealer.AddCard(new Card(Rank.TEN, Suit.HEART));

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
			game.Decision = true;
            game.CheckScores();

            Assert.IsTrue(game.Status == GameState.DRAW);
        }

        [Test()]
        public void TestLose()
        {
            Player player = new Player();
            Dealer dealer = new Dealer();
            Deck deck = new Deck();
            player.AddCard(new Card(Rank.NINE, Suit.DIAMOND));
            player.AddCard(new Card(Rank.TEN, Suit.SPADE));

            dealer.AddCard(new Card(Rank.TEN, Suit.CLUB));
            dealer.AddCard(new Card(Rank.TEN, Suit.HEART));

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
			game.Decision = true;
            game.CheckScores();

            Assert.IsTrue(game.Status == GameState.LOSE);
        }

        [Test()]
        public void TestBust()
        {
            Player player = new Player();
            Dealer dealer = new Dealer();
            Deck deck = new Deck();
            player.AddCard(new Card(Rank.NINE, Suit.DIAMOND));
            player.AddCard(new Card(Rank.TEN, Suit.SPADE));
            player.AddCard(new Card(Rank.FIVE, Suit.SPADE));

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
            game.CheckScores();

            Console.WriteLine(game.Status);
            Assert.IsTrue(game.Status == GameState.LOSE);
        }

        [Test()]
        public void Test5CardsUnder21Win()
        {
            Player player = new Player();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            player.AddCard(new Card(Rank.TWO, Suit.DIAMOND));
            player.AddCard(new Card(Rank.TWO, Suit.SPADE));
            player.AddCard(new Card(Rank.ACE, Suit.SPADE));
            player.AddCard(new Card(Rank.FOUR, Suit.SPADE));
            player.AddCard(new Card(Rank.ACE, Suit.HEART));

            dealer.AddCard(new Card(Rank.TEN, Suit.HEART));
            dealer.AddCard(new Card(Rank.TEN, Suit.SPADE));

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
            game.CheckScores();
            Assert.IsTrue(game.Status == GameState.WIN);
        }
    }
}
