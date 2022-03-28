import React, { FC, Fragment, useEffect, useState } from "react";
import { AddressSearchModel } from "../../app/models/addresses/AddressSearchModel";
import { IAddressSearchModel } from "../../app/models/addresses/interfaces/IAddressSearchModel";
import { IAddressSearchResultsModel } from "../../app/models/addresses/interfaces/IAddressSearchResultsModel";
import AddressService from "../../app/services/addressService";
import { AddressGrid } from "./components/addressGrid";
import AddressSearchForm from "./components/addressSearchForm";

const Addresses: FC = () => {
    const [addresses, setAddresses] = useState<IAddressSearchResultsModel[]>([]);
    const addressService = new AddressService();

    const searchAddress = (addressSearchFields: IAddressSearchModel): void => {
        addressService.searchAddresses(addressSearchFields).then((response) => {
            if(response)
            {
                setAddresses(response);
            }
        });
    }

    useEffect(() => {
        searchAddress(new AddressSearchModel());
    }, []);

    return(
        <Fragment>
            <div>
                <h1>Address Search</h1>
            </div>
            <div>
                <AddressSearchForm HandleSearch={searchAddress} />
            </div>
            <div>
                <AddressGrid rows={addresses} />
            </div>  
        </Fragment>
    );
}
export default Addresses;

