using ICities;
using UnityEngine;
using ColossalFramework;
using System;
using System.Globalization;


public class vehiclestats
{
    private int dataLimit = 1500;

    public double activevehicles = 0,
        garbagetrucksinuse = 0, firetrucksinuse = 0, hearseinuse = 0, policecarsinuse = 0, healthcarevehiclesinuse = 0,
        maintenancetrucksinuse = 0, snowtrucksinuse = 0,
        passengerbusses = 0, passengerships = 0, passengertrains = 0, passengerplanes = 0, passengermetro = 0, passengertram = 0,
        cargocars = 0, cargobusses = 0, cargoships = 0, cargotrains = 0, cargoplanes = 0, cargometro = 0, cargotrams = 0,
        commercialcars = 0, commercialbusses = 0, commercialships = 0, commercialtrains = 0, commercialplanes = 0, commercialmetro = 0, commercialtrams = 0,
        residentialcars = 0, residentialbusses = 0, residentialships = 0, residentialtrains = 0, residentialplanes = 0, residentialmetro = 0, residentialtrams = 0,
        waitcounter = 0, blockcounter = 0, highestwait = 0, highestblock = 0, highestdelay = 0, delay = 0, bodiesintransit = 0,
        cargoexports = 0, cargoimports = 0,
        carexports = 0, carimports = 0, trainexports = 0, trainimports = 0, tramimports = 0,
        metroexports = 0, metroimports = 0, shipexports = 0, shipimports = 0, tramexports = 0,
        planeexports = 0, planeimports = 0,
        industryimports = 0, industryexports = 0, commercialimports = 0, commercialexports = 0, residentialimports = 0, residentialexports = 0,
        intracitytransports = 0;


    public bool checkbuilding(Building b, ushort buildingIndex)
    {
        bool isEmptying = false;
        if ((b.m_flags & Building.Flags.Downgrading) != Building.Flags.None) isEmptying = true;

        return b.m_flags.IsFlagSet(Building.Flags.Created)
            && !b.m_flags.IsFlagSet(Building.Flags.Deleted)
            && !b.m_flags.IsFlagSet(Building.Flags.Untouchable)
            && !b.Info.m_buildingAI.IsFull(buildingIndex, ref b) // is full
            && !isEmptying; // is emptying
         

    }

    public string getStats()
    {
        string val = "activevehicles, garbagetrucksinuse, firetrucksinuse, hearseinuse, policecarsinuse, healthcarevehiclesinuse, maintenancetrucksinuse, snowtrucksinuse, passengerbusses,"+
                    "passengerships, passengertrains, passengerplanes, passengermetro, passengertram, cargocars, cargobusses, cargoships, cargotrains, cargoplanes, cargometro, cargotrams, commercialcars,"+
                    "commercialbusses, commercialships, commercialtrains, commercialplanes, commercialmetro, commercialtrams, residentialcars, residentialbusses, residentialships, residentialtrains, residentialplanes, residentialmetro, residentialtrams,"+
                    "waitcounter, blockcounter, highestwait, highestblock, bodiesintransit, cargoexports, cargoimports, carexports, carimports, trainexports, trainimports,"+
                    "tramimports, metroexports, metroimports, shipexports, shipimports, tramexports, planeexports, planeimports, industryimports, industryexports, commercialimports, commercialexports,"+
                    "residentialimports, residentialexports, intracitytransports" + Environment.NewLine;

        val += 
        activevehicles + "," + garbagetrucksinuse + "," + firetrucksinuse + "," + hearseinuse + "," + policecarsinuse + "," + healthcarevehiclesinuse + "," +
        maintenancetrucksinuse + "," + snowtrucksinuse + "," +passengerbusses + "," + passengerships + "," + passengertrains + "," + passengerplanes + "," + passengermetro + "," + passengertram + "," +
        cargocars + "," + cargobusses + "," + cargoships + "," + cargotrains + "," + cargoplanes + "," + cargometro + "," + cargotrams + "," +
        commercialcars + "," + commercialbusses + "," + commercialships + "," + commercialtrains + "," + commercialplanes + "," + commercialmetro + "," + commercialtrams + "," +
        residentialcars + "," + residentialbusses + "," + residentialships + "," + residentialtrains + "," + residentialplanes + "," + residentialmetro + "," + residentialtrams + "," +
        waitcounter + "," + blockcounter + "," + highestwait + "," + highestblock + "," + bodiesintransit + "," +
        cargoexports + "," + cargoimports + "," + carexports + "," + carimports + "," + trainexports + "," + trainimports + "," + tramimports + "," +
        metroexports + "," + metroimports + "," + shipexports + "," + shipimports + "," + tramexports + "," +
        planeexports + "," + planeimports + "," + industryimports + "," + industryexports + "," + commercialimports + "," + commercialexports + "," 
        + residentialimports + "," + residentialexports + "," +intracitytransports;

        return val;
    }
     

    public vehiclestats()
    {

        VehicleManager vm = Singleton<VehicleManager>.instance;
        BuildingManager bm = Singleton<BuildingManager>.instance;
   
        for (int i = 0; i < vm.m_vehicles.m_buffer.Length; i++)
        {
            Vehicle myv = vm.m_vehicles.m_buffer[i];
            if (!myv.m_flags.IsFlagSet(Vehicle.Flags.Created)) continue;
            if (myv.m_flags.IsFlagSet(Vehicle.Flags.Deleted)) continue;
            if (myv.m_flags < 0) continue;
            

            if (myv.Info.m_vehicleType == VehicleInfo.VehicleType.Car)
            {
                activevehicles++;
            }


            switch (myv.Info.m_class.m_service)
            {
                case ItemClass.Service.Road:
                    maintenancetrucksinuse++;
                    break;
                case ItemClass.Service.Garbage:
                    garbagetrucksinuse++;
                    break;
                case ItemClass.Service.FireDepartment:
                    firetrucksinuse++;
                    break;
                case ItemClass.Service.PoliceDepartment:
                    policecarsinuse++;
                    break;
                case ItemClass.Service.HealthCare:
                    healthcarevehiclesinuse++;
                    break;

                case ItemClass.Service.PublicTransport:
                    switch (myv.Info.m_class.m_subService)
                    {
                        case ItemClass.SubService.PublicTransportPlane:
                            passengerplanes++;
                            break;
                        case ItemClass.SubService.PublicTransportTrain:
                            passengertrains++;
                            break;
                        case ItemClass.SubService.PublicTransportTram:
                            passengertram++;
                            break;
                        case ItemClass.SubService.PublicTransportShip:
                            passengerships++;
                            break;
                        case ItemClass.SubService.PublicTransportBus:
                            passengerbusses++;
                            break;
                        case ItemClass.SubService.PublicTransportMetro:
                            passengermetro++;
                            break;
                    }
                    break;
                case ItemClass.Service.Commercial:
                    switch (myv.Info.m_vehicleType)
                    {
                        case VehicleInfo.VehicleType.Car:
                            commercialcars++;
                            break;
                        case VehicleInfo.VehicleType.Metro:
                            commercialmetro++;
                            break;
                        case VehicleInfo.VehicleType.Plane:
                            commercialplanes++;
                            break;
                        case VehicleInfo.VehicleType.Ship:
                            commercialships++;
                            break;
                        case VehicleInfo.VehicleType.Train:
                            commercialtrains++;
                            break;
                        case VehicleInfo.VehicleType.Tram:
                            commercialtrams++;
                            break;
                    }
                    break;
                case ItemClass.Service.Industrial:
                    switch (myv.Info.m_vehicleType)
                    {
                        case VehicleInfo.VehicleType.Car:
                            cargocars++;
                            break;
                        case VehicleInfo.VehicleType.Metro:
                            cargometro++;
                            break;
                        case VehicleInfo.VehicleType.Plane:
                            cargoplanes++;
                            break;
                        case VehicleInfo.VehicleType.Ship:
                            cargoships++;
                            break;
                        case VehicleInfo.VehicleType.Train:
                            cargotrains++;
                            break;
                        case VehicleInfo.VehicleType.Tram:
                            cargotrams++;
                            break;
                    }
                    break;
                case ItemClass.Service.Residential:
                    switch (myv.Info.m_vehicleType)
                    {
                        case VehicleInfo.VehicleType.Car:
                            residentialcars++;
                            break;
                        case VehicleInfo.VehicleType.Metro:
                            residentialmetro++;
                            break;
                        case VehicleInfo.VehicleType.Plane:
                            residentialplanes++;
                            break;
                        case VehicleInfo.VehicleType.Ship:
                            residentialships++;
                            break;
                        case VehicleInfo.VehicleType.Train:
                            residentialtrains++;
                            break;
                        case VehicleInfo.VehicleType.Tram:
                            residentialtrams++;
                            break;
                    }
                    break;


            }//end switch
            





        }//end for loop


       

    }//end vehicle stats

    public string getAllVehicles()
    {
        VehicleManager vm = Singleton<VehicleManager>.instance;
        BuildingManager bm = Singleton<BuildingManager>.instance;

        string allcars = "";
        int count = 0;

        allcars = allcars + "id,info,flags,type,path,source,destination,tourist,trailing,wait" + Environment.NewLine;

        for (int i = 0; i < vm.m_vehicles.m_buffer.Length; i++)
        {
            Vehicle myv = vm.m_vehicles.m_buffer[i];
            if (!myv.m_flags.IsFlagSet(Vehicle.Flags.Created)) continue;
            if (myv.m_flags.IsFlagSet(Vehicle.Flags.DummyTraffic)) continue;
            if (myv.m_flags.IsFlagSet(Vehicle.Flags.Deleted)) continue;
            if (myv.m_flags < 0) continue;

            if (!myv.Info.ToString().Contains("Ore Truck") &&
                    !myv.Info.ToString().Contains("Forestry Trailer") &&
                    !myv.Info.ToString().Contains("Oil Truck Trailer") &&
                    !myv.Info.ToString().Contains("Train Passenger") &&
                    !myv.Info.ToString().Contains("Tractor Trailer") &&
                    !myv.Info.ToString().Contains("Train Cargo"))
            {
                allcars = allcars + i + ','
                            + myv.Info.ToString() + ','
                            + (myv.m_flags + "").Replace(",", "-") + ','
                            + myv.GetType() + ','
                            + myv.m_path + ','
                            + myv.m_sourceBuilding + ','
                            + myv.m_targetBuilding + ','
                            + myv.m_touristCount + ','
                            + myv.m_trailingVehicle + ','
                            + myv.m_waitCounter + ','
                            + Environment.NewLine;
                count++;
            }

            if (count > dataLimit)
            {
                return allcars;
            }
        }//end for
        return allcars;
    }//end get all cars


}//end namespace