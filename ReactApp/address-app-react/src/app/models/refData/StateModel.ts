import { IStateModel } from "./interfaces/IStateModel";

export class StateModel implements IStateModel{
    id: string = "";
    abbreviation: string | null = null;
    name: string | null = null;
}