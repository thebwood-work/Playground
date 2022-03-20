import { IAddressModel } from "./interfaces/IAddressModel";

export class AddressModel implements IAddressModel{
    id: string | null = null;
    address: string | null = null;
    city: string | null = null;
    stateid: string | null = null;

}