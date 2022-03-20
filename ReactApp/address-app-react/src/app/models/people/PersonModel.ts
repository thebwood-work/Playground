import { IPersonModel } from "./interfaces/IPersonModel";

export class PersonModel implements IPersonModel{
    id: string | null = null;
    firstName: string | null = '';
    lastName: string | null = '';
    dateOfBirth: Date | null = null;
}