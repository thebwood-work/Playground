import { AddressModel } from "../models/addresses/AddressModel";
import { AddressSearchModel } from "../models/addresses/AddressSearchModel";
import Service from "./service";

export default class AddressService {
    searchAddresses = async (AddressSearchFields: AddressSearchModel) => {
        try {
            return await Service.Addresses.search(AddressSearchFields);
        } 
        catch (error) {
            console.log(error);
        }

    }
    loadAddresses = async () => {
        try {
            return await Service.Addresses.list();
        } 
        catch (error) {
            console.log(error);
        }
    }

    loadAddress = async (id: string) => {
        try {
            return await Service.Addresses.details(id);
        } 
        catch (error) {
            console.log(error);
        }
    }

    saveAddress = async (Address: AddressModel) => {
        try {
            return await Service.Addresses.save(Address);
        } 
        catch (error) {
            console.log(error);
        }
    }
}