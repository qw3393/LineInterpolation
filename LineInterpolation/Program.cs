// See https://aka.ms/new-console-template for more information

double x1 = 2.0; // x-coordinate of the first point
double y1 = 3.0; // y-coordinate of the first point
double x2 = 5.0; // x-coordinate of the second point
double y2 = 8.0; // y-coordinate of the second point

double distance = 3.0; // Desired extension distance
double x = 3.5; // Point at which you want to interpolate

double InterPolationValue = LinearInterpolation(x, x1, x2, y1, y2);
Console.WriteLine($"Interpolated value at x = {x}: {InterPolationValue}");

Console.WriteLine($"Og point: ({x2}, {y2})");
ExtendLine(ref x2, ref y2, x1, y1, distance);
Console.WriteLine($"Extended point: ({x2}, {y2})");

static double LinearInterpolation(double x, double x0, double x1, double y0, double y1)
{
    // Calculate the slope (m) between the two points
    double slope = (y1 - y0) / (x1 - x0);
        
    // Use the slope to interpolate the value at 'x'
    double interpolatedValue = y0 + slope * (x - x0);
        
    return interpolatedValue;
}

static void ExtendLine(ref double x2, ref double y2, double x1, double y1, double d)
{
    // Calculate the direction vector between the two points
    double dx = x2 - x1;
    double dy = y2 - y1;

    // Calculate the length of the direction vector
    //double length = Math.Sqrt(dx * dx + dy * dy);
    double length = dx;

    // Calculate the scaling factor to extend the line by distance 'd'
    double scale = (length + d) / length;

    // Extend the line by updating the second point
    x2 = x1 + dx * scale;
    y2 = y1 + dy * scale;
}