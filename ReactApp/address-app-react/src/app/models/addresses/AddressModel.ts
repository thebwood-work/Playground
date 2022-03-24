import { IAddressModel } from "./interfaces/IAddressModel";

export class AddressModel implements IAddressModel{
    id: string | null = null;
    streetNumber: string | null = null;
    streetName: string | null = null;
    city: string | null = null;
    stateId: string | null = null;
    zipCode: string | null = null;

}