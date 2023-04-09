using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// This class serves as a wrapper for the external C++ DLL, SetOperations.dll.
public static class MyCppDLLWrapper
{
    // Import the "compute_intersection_of_arrays" function from SetOperations.dll.
    // This function takes two arrays, their sizes, an output array, and an output size (passed by reference).
    // It computes the intersection of the input arrays and stores the result in the output array.
    [DllImport("SetOperations.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void compute_intersection_of_arrays(int[] array1, int array1Size, int[] array2, int array2Size, int[] outputArray, out int outputSize);
}


