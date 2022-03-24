import { IPersonsearchResultsModel } from "./interfaces/IPersonSearchResultsModel";

export class PersonsearchResultsModel implements IPersonsearchResultsModel{
    id: string | null = null;
    firstName: string | null = '';
    lastName: string | null = '';
    dateOfBirth: Date | null = null;
}