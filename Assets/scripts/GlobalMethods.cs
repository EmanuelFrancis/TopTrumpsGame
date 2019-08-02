using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMethods  {

    public static int IntValue;

    public static int stringToint(string changeMeToInt)
    {
        // Convert Text number into String
        int.TryParse(changeMeToInt, out IntValue);
        //  int IntValue = AppearancesInt;

        return IntValue;
    }

}
