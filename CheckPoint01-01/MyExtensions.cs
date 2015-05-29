using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    static class MyExtensions
    {
        public static List<TransportUnit> ExtUnitsSelectByType<T>(this List<TransportUnit> RangeList)
        {
            return RangeList.FindAll(x => x is T);
        }

        public static List<TransportUnit> ExtSelectSortByFuelCons(this List<TransportUnit> RangeList, double min, double max)
        {
            if (RangeList != null)
            {
                IEnumerable<TransportUnit> newList = new List<TransportUnit>();
                newList = from c in RangeList where (c is IisTransport) orderby ((c as IisTransport).FuelCons) select c;
                if ((max > 0) && (max > min))
                    newList = from c in newList where (((c as IisTransport).FuelCons >= min) && ((c as IisTransport).FuelCons <= max)) select c;
                return newList.ToList<TransportUnit>();
            }
            else return null;
        }

        public static List<TransportUnit> ExtSelectSortByMaxSpeed(this List<TransportUnit> RangeList, double min, double max)
        {
            if (RangeList != null)
            {
                IEnumerable<TransportUnit> newList = new List<TransportUnit>();
                newList = from c in RangeList where (c is IisTransport) orderby ((c as IisTransport).MaxSpeed) select c;
                if ((max > 0) && (max > min))
                    newList = from c in newList where (((c as IisTransport).MaxSpeed >= min) && ((c as IisTransport).MaxSpeed <= max)) select c;
                return newList.ToList<TransportUnit>();
            }
            else return null;
        }

        public static List<TransportUnit> ExtSelectSortByWayRange(this List<TransportUnit> RangeList, double min, double max)
        {           
            if (RangeList != null)
            {
                IEnumerable<TransportUnit> newList = new List<TransportUnit>();
                newList = from c in RangeList where (c is IisTransport) orderby ((c as IisTransport).WayRange) select c;
                if ((max > 0) && (max > min))
                    newList = from c in newList where (((c as IisTransport).WayRange >= min) && ((c as IisTransport).WayRange <= max)) select c;
                return newList.ToList<TransportUnit>();
            }
            else return null;
        }

        public static List<TransportUnit> ExtSelectSortByCostValue(this List<TransportUnit> RangeList, double min, double max)
        {
            if (RangeList != null)
            {
                IEnumerable<TransportUnit> newList = new List<TransportUnit>();
                newList = from c in RangeList where (c is IisMaterialValue) orderby ((c as IisMaterialValue).CostValue) select c;
                if ((max > 0) && (max > min))
                    newList = from c in newList where (((c as IisMaterialValue).CostValue >= min) && ((c as IisMaterialValue).CostValue <= max)) select c;
                return newList.ToList<TransportUnit>();
            }
            else return null;
        }
        
        public static void ExtUnitsPrint(this List<TransportUnit> RangeList, ConsoleColor color)
        {
            if (RangeList != null)
                for (int i = 0; i < RangeList.Count; i++)
                {
                    Console.ForegroundColor = color;
                    Console.Write("{0,2} {1,5} ", i + 1, (RangeList[i] as TransportUnit).ID);
                    Console.Write("{0,8} ", (RangeList[i] as TransportUnit).UnitKind);

                    if (RangeList[i] is ManUnit) Console.Write("{0,-15}", (RangeList[i] as TransportUnit).Name + ' ' + (RangeList[i] as ManUnit).FirstName);
                    else Console.Write("{0,-15}", (RangeList[i] as TransportUnit).Name);

                    if (RangeList[i] is AircraftUnit)
                    {
                        Console.Write("FC:{0,5} ", (RangeList[i] as IisTransport).FuelCons);
                        Console.Write("MS:{0,5} ", (RangeList[i] as IisTransport).MaxSpeed);
                        Console.Write("FV:{0,5} ", (RangeList[i] as IisTransport).FuelValue);
                        Console.Write("VC:{0,5} ", (RangeList[i] as IhasPassenger).VolumeCapacity);
                        Console.WriteLine("WC:{0,5} ", (RangeList[i] as IhasPassenger).WeightCapacity);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("          RANGE:{0,30} km", (RangeList[i] as IisTransport).WayRange);
                        Console.ForegroundColor = color;
                    }
                    else if (RangeList[i] is CarUnit)
                    {
                        Console.Write("FC:{0,5} ", (RangeList[i] as IisTransport).FuelCons);
                        Console.Write("MS:{0,5} ", (RangeList[i] as IisTransport).MaxSpeed);
                        Console.Write("CV:{0,7} ", (RangeList[i] as CarUnit).CostValue);
                    }
                    else if (RangeList[i] is DriverUnit)
                    {
                        Console.Write("Drive lisences: ");
                        if ((RangeList[i] as DriverUnit).CarDriveLicense) Console.Write(" #CAR# ");
                        if ((RangeList[i] as DriverUnit).TrainDriveLicense) Console.Write(" #TRAIN# ");
                        if ((RangeList[i] as DriverUnit).AircraftDriveLicense) Console.Write(" #AIRCRAFT# ");
                    }
                    else if (RangeList[i] is BaggageUnit)
                    {
                        Console.Write("VOLUME:{0,7} ", (RangeList[i] as BaggageUnit).Volume);
                        Console.Write("WEIGHT:{0,7} ", (RangeList[i] as BaggageUnit).Weight);
                    }
                    Console.WriteLine();
                }
            Console.WriteLine();
        }
    }
}
