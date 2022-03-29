import { IAddressDetailModel } from "./interfaces/IAddressDetailModel";

export class AddressDetailModel implements IAddressDetailModel{
    id: string | null = null;
    streetNumber: string | null = null;
    streetName: string | null = null;
    city: string | null = null;
    stateId: string | null = null;
    stateName: string | null = null;
    stateAbbreviation: string | null = null;
    zipCode: string | null = null;

}