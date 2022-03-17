import { IPersonModel } from "./interfaces/IPersonModel";

export class PersonModel implements IPersonModel{
    id: string | null = null;
    firstName: string = '';
    lastName: string = '';
    dateOfBirth: Date | null = null;
}