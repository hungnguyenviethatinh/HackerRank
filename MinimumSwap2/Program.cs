Animal dog = new Dog("Mích Ky");
Animal cat = new Cat("Mèo Mun");

dog.PrintName();
cat.PrintName();

bool isDogAnimal = dog.GetType() == typeof(Animal);
bool isCatAnimal = cat.GetType() == typeof(Animal);
isDogAnimal = dog is Animal;
isDogAnimal = dog is Dog;
isCatAnimal = cat is Animal;
isCatAnimal = cat is Cat;

object animal = new Animal("Con lợn");
dog = animal as Dog;
dog = (Dog)animal;
dog.PrintName();
cat = animal as Cat;
cat = (Cat)animal;
cat.PrintName();

public class Animal(string name)
{
    public virtual void PrintName()
    {
        Console.WriteLine(name);
    }
}

public class Dog(string name) : Animal(name)
{
}

public class Cat(string name): Animal(name)
{
}

public class Pig(string name): Animal(name)
{
}
