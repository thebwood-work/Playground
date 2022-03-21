import { IPersonSearchModel } from "./interfaces/IPersonSearchModel";

export class PersonSearchModel implements IPersonSearchModel{
    firstName: string | null = null;
    lastName: string | null = null;
}