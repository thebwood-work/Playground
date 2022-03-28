import { PersonDetailModel } from "../models/people/PersonDetailModel";
import { PersonSearchModel } from "../models/people/PersonSearchModel";
import Service from "./service";

export default class PeopleService {
    searchPeople = async (PersonSearchFields: PersonSearchModel) => {
        try {
            return await Service.People.search(PersonSearchFields);
        } 
        catch (error) {
            console.log(error);
        }

    }
    loadPeople = async () => {
        try {
            return await Service.People.list();
        } 
        catch (error) {
            console.log(error);
        }
    }

    loadPerson = async (id: string) => {
        try {
            return await Service.People.details(id);
        } 
        catch (error) {
            console.log(error);
        }
    }

    savePerson = async (Person: PersonDetailModel) => {
        try {
            return await Service.People.save(Person);
        } 
        catch (error) {
            console.log(error);
        }
    }

    deletePerson = async (id: string) => {
        try {
            return await Service.People.delete(id);
        } 
        catch (error) {
            console.log(error);
        }
    }
}