import React, { FC, Fragment, useEffect, useState } from "react";
import { AddressSearchModel } from "../../app/models/addresses/AddressSearchModel";
import { IAddressSearchModel } from "../../app/models/addresses/interfaces/IAddressSearchModel";
import { IAddressSearchResultsModel } from "../../app/models/addresses/interfaces/IAddressSearchResultsModel";
import { ICountryModel } from "../../app/models/refData/interfaces/ICountryModel";
import { IStateModel } from "../../app/models/refData/interfaces/IStateModel";
import AddressService from "../../app/services/addressService";
import RefDataService from "../../app/services/refDataService";
import { AddressGrid } from "./components/addressGrid";
import AddressSearchForm from "./components/addressSearchForm";

const Addresses: FC = () => {
    const [addresses, setAddresses] = useState<IAddressSearchResultsModel[]>([]);
    const [countries, setCountries] = useState<ICountryModel[]>([]);
    const [states, setStates] = useState<IStateModel[]>([]);
    const addressService = new AddressService();
    const refDataService = new RefDataService();

    const searchAddress = (addressSearchFields: IAddressSearchModel): void => {
        refDataService.loadCountries().then((response) => {
            if(response)
                setCountries(response);
        });

        refDataService.loadStates().then((response) => {
            if(response)
                setStates(response);
        });

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
                <AddressSearchForm HandleSearch={searchAddress} Countries={countries} States={states} />
            </div>
            <div>
                <AddressGrid rows={addresses} />
            </div>  
        </Fragment>
    );
}
export default Addresses;

