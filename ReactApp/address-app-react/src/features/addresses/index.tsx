import axios from "axios";
import React, { FC, Fragment, useEffect, useState } from "react";
import { AddressSearchModel } from "../../app/models/addresses/AddressSearchModel";
import { IAddressSearchModel } from "../../app/models/addresses/interfaces/IAddressSearchModel";
import { IAddressSearchResultsModel } from "../../app/models/addresses/interfaces/IAddressSearchResultsModel";
import { AddressGrid } from "./components/addressGrid";
import AddressSearchForm from "./components/addressSearchForm";

const Addresses: FC = () => {
    const [addresses, setAddresses] = useState<IAddressSearchResultsModel[]>([]);

    const searchAddress = (addressSearchFields: IAddressSearchModel): void => {
        axios.post<IAddressSearchResultsModel[]>('https://localhost:5010/addresses/search', addressSearchFields).then((response) => {
            if(response && response.data)
            {
                setAddresses(response.data);
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

