import { ICountryModel } from "./interfaces/ICountryModel";

export class CountryModel implements ICountryModel{
    id: string = "";
    abbreviation: string | null = null;
    name: string | null = null;
}