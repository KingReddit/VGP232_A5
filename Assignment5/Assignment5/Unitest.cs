using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Assignment5
{
    [TestFixture]
    class Unitest
    {
            private Inventory inventory;
            private Item item1;
            private Item item2;
            private Item item3;
            private Item foundItem = null;

            [SetUp]
            public void Setup()
            {
                inventory = new Inventory(5);
                item1 = new Item("M4", 1, ItemGroup.Equipment);
                item2 = new Item("Sandwich", 1, ItemGroup.Consumable);
                item3 = new Item("Key1", 1, ItemGroup.Key);
            }

            [Test]
            public void RemoveItem()
            {
                Assert.IsTrue(inventory.AddItem(item1));
                Assert.IsTrue(inventory.AddItem(item2));

                Assert.IsTrue(inventory.TakeItem(item1));
                Assert.IsTrue(foundItem != null);
                Assert.IsTrue(inventory.AvailableSlots == 1);

                Assert.IsFalse(inventory.TakeItem(item3));
                Assert.IsTrue(foundItem == null);
                Assert.IsTrue(inventory.AvailableSlots == 1);
            }

            [Test]
            public void AddItem()
            {
                Assert.IsTrue(inventory.AddItem(item1));
                Assert.IsTrue(inventory.AvailableSlots == 1);

                Assert.IsTrue(inventory.AddItem(item2));
                Assert.IsTrue(inventory.AvailableSlots == 0);

                Assert.IsFalse(inventory.AddItem(item3));
                Assert.IsTrue(inventory.AvailableSlots == 0);

                var tempList = inventory.ListAllItems();
                Assert.AreEqual(item1, tempList[0]);
                Assert.AreEqual(item2, tempList[1]);
            }

            [Test]
            public void Reset()
            {
                Assert.IsTrue(inventory.AddItem(item1));
                Assert.IsTrue(inventory.AddItem(item2));

                inventory.Reset();

                Assert.IsTrue(inventory.ListAllItems().Count == 0);
            }
        }
    }
}
}
