using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public static class MyCppDLLWrapper
{
    [DllImport("SetOperations.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void compute_intersection_of_arrays(int[] array1, int array1Size, int[] array2, int array2Size, int[] outputArray, out int outputSize);
}

