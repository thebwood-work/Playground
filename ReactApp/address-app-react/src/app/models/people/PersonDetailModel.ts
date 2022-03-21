import { IPersonDetailModel } from "./interfaces/IPersonDetailModel";

export class PersonDetailModel implements IPersonDetailModel{
    id: string | null = null;
    firstName: string | null= null;
    lastName: string | null= null;
    dateOfBirth: Date | null= null;
}