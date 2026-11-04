using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Coord c = (Coord)obj;
            return (X == c.X) && (Y == c.Y);
        }
    }
}

public struct Plot
{

    public Plot(Coord topLeft, Coord topRight, Coord bottomLeft, Coord bottomRight)
    {
        TopLeft = topLeft;
        TopRight = topRight;
        BottomLeft = bottomLeft;
        BottomRight = bottomRight;
    }
    public Coord TopLeft { get; }
    public Coord TopRight { get; }
    public Coord BottomLeft { get; }
    public Coord BottomRight { get; }

    public double GetLongestSide()
    {
        double width = Math.Abs(TopRight.X - TopLeft.X);
        double height = Math.Abs(BottomLeft.Y - TopLeft.Y);

        return Math.Max(width, height);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Plot p = (Plot)obj;
            return TopLeft.Equals(p.TopLeft) && TopRight.Equals(p.TopRight) && BottomLeft.Equals(p.BottomLeft) && BottomRight.Equals(p.BottomRight);
        }

    }
}


public class ClaimsHandler
{
    List<Plot> plots = [];
    public void StakeClaim(Plot plot)
    {
        plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return plots.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return plots.Count > 0 && plots[^1].Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        Plot longestPlot = plots[0];
        double longestLength = longestPlot.GetLongestSide();

        for (int i = 1; i < plots.Count; i++)
        {
            if (longestLength < plots[i].GetLongestSide())
            {
                longestLength = plots[i].GetLongestSide();
                longestPlot = plots[i];
            }
        }

        return longestPlot;
    }
}
