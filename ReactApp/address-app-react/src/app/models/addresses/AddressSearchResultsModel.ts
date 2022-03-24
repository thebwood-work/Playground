import { IAddressSearchResultsModel } from "./interfaces/IAddressSearchResultsModel";

export class AddressSearchResultsModel implements IAddressSearchResultsModel{
    id: string | null = null;
    streetNumber: string | null = null;
    streetName: string | null = null;
    city: string | null = null;
    stateId: string | null = null;
    stateName: string | null = null;
    zipCode: string | null = null;

}