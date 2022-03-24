import { IAddressSearchModel } from "./interfaces/IAddressSearchModel";

export class AddressSearchModel implements IAddressSearchModel{
    id: string | null = null;
    streetNumber: string | null =null;
    streetName: string | null = null;
    city: string | null = null;
    stateId: string | null = null;
    zipCode: string | null = null;

}