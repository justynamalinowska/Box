# Lab-03. Well formed class - Pudelko

You are involved in the development of a system to support a courier company and optimize loading. Your task is to create a class called "Pudelko" (Box in English).

A "Pudelko" is a rectangular parallelepiped with given edge lengths (conventionally: length, height, width). These dimensions can be given in millimeters, centimeters, or meters - as real values. Digits outside the range for a given unit are cut off (for example, for 2.54637 m, we take 2.546 m, which is 254.6 cm, which is 2546 mm)!

We assume that the maximum single dimension of a box does not exceed 10 meters (due to limited loading possibilities).

Your task is to implement the "Pudelko" class that meets the following conditions:

Objects of the "Pudelko" class are immutable.
The default "Pudelko" is a rectangular parallelepiped with edges a, b, c of dimensions 10 cm × 10 cm × 10 cm.
The class is sealed (it cannot be inherited from).
