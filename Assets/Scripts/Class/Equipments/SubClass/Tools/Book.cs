using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Tool
{
    private static Book book = new Book();

    public static Book Current => book;
    private Book() {
        assets = 1;
        intelligence = 1;
    }
}
