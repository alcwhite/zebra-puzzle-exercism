using System;
using System.Collections.Generic;
using System.Linq;

public enum Color { Red , Green , Ivory , Yellow , Blue }
public enum Nationality { Englishman , Spaniard , Ukranian , Japanese , Norwegian }
public enum Pet { Dog , Snails , Fox , Horse , Zebra }
public enum Drink { Coffee , Tea , Milk , OrangeJuice , Water }
public enum Smoke { OldGold , Kools , Chesterfields , LuckyStrike , Parliaments }
public enum Number { One, Two, Three, Four, Five }

public class House
{
    public Color color;
    public Nationality nationality;
    public Pet pet;
    public Drink drink;
    public Smoke smoke;
    public Number number;
}

// Chesterfields - house next to fox
// Kools - house next to horse
// Norwegian - next to blue house


public static class ZebraPuzzle
{
    public static IEnumerable<House> SolveRiddle()
    {
        House[] allHouses = new House[5];
        allHouses.Select((x, i) => x.number = (Number)i);
        foreach (House house in allHouses)
        {
            if (house.number == Number.One)
                house.nationality = Nationality.Norwegian;
            if (house.number == Number.Three)
                house.drink = Drink.Milk;
            if (house.number == allHouses.First(h => h.color == Color.Ivory).number + 1)
                house.color = Color.Green;
            if (house.color == Color.Green)
                allHouses.First(h => h.number == house.number - 1).color = Color.Ivory;
            if (house.number == allHouses.First(h => h.color == Color.Green).number - 1)
                house.color = Color.Ivory;
            if (house.color == Color.Ivory)
                allHouses.First(h => h.number == house.number + 1).color = Color.Green;
            if (house.nationality == Nationality.Ukranian)
                house.drink = Drink.Tea;
            if (house.drink == Drink.Tea)
                house.nationality = Nationality.Ukranian;
            if (house.smoke == Smoke.OldGold)
                house.pet = Pet.Snails;
            if (house.pet == Pet.Snails)
                house.smoke = Smoke.OldGold;
            if (house.drink == Drink.Coffee)
                house.color = Color.Green;
            if (house.color == Color.Green)
                house.drink = Drink.Coffee;
            if (house.nationality == Nationality.Spaniard)
                house.pet = Pet.Dog;
            if (house.pet == Pet.Dog)
                house.nationality = Nationality.Spaniard;
            if (house.nationality == Nationality.Englishman)
                house.color = Color.Red;
            if (house.color == Color.Red)
                house.nationality = Nationality.Englishman;
            if (house.smoke == Smoke.Kools)
                house.color = Color.Yellow;
            if (house.color == Color.Yellow)
                house.smoke = Smoke.Kools;
            if (house.smoke == Smoke.LuckyStrike)
                house.drink = Drink.OrangeJuice;
            if (house.drink == Drink.OrangeJuice)
                house.smoke = Smoke.LuckyStrike;
            if (house.nationality == Nationality.Japanese)
                house.smoke = Smoke.Parliaments;
            if (house.smoke == Smoke.Parliaments)
                house.nationality = Nationality.Japanese;
            
        }
        
        return allHouses;
    }
    public static Nationality DrinksWater()
    {
        return SolveRiddle().First(x => x.drink == Drink.Water).nationality;
    }

    public static Nationality OwnsZebra()
    {
        return SolveRiddle().First(x => x.pet == Pet.Zebra).nationality;
    }
}