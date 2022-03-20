import { IPersonSearch } from "./interfaces/IPersonSearch";

export class PersonSearch implements IPersonSearch{
    firstName: string | null = null;
    lastName: string | null = null;
}