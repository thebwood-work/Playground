import { IPersonSearchResultsModel } from "./interfaces/IPersonSearchResultsModel";

export class PersonSearchResultsModel implements IPersonSearchResultsModel{
    id: string | null = null;
    firstName: string | null = '';
    lastName: string | null = '';
    dateOfBirth: Date | null = null;
}