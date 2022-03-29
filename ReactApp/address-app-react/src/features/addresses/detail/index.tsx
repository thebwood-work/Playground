import { Alert, Button, Container, FormControl, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import React, { FC, Fragment, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { AddressDetailModel } from "../../../app/models/addresses/AddressDetailModel";
import { IAddressDetailModel } from "../../../app/models/addresses/interfaces/IAddressDetailModel";
import { ICountryModel } from "../../../app/models/refData/interfaces/ICountryModel";
import { IStateModel } from "../../../app/models/refData/interfaces/IStateModel";
import { StateModel } from "../../../app/models/refData/StateModel";
import AddressService from "../../../app/services/addressService";
import RefDataService from "../../../app/services/refDataService";


const AddressDetail: FC = () => {
    const addressService = new AddressService();
    const refDataService = new RefDataService();
    const navigate = useNavigate();
    const { id } = useParams();
    const [address, setAddress] = useState<IAddressDetailModel>(new AddressDetailModel());
    const [countries, setCountries] = useState<ICountryModel[]>([]);
    const [states, setStates] = useState<IStateModel[]>([]);
    const { streetName, streetNumber, city, stateId, stateName, stateAbbreviation, zipCode } = address;
    const [errorMessages, setErrorMessages] = useState<string[]>([]);

    useEffect(() => {
        refDataService.loadCountries().then((response) => {
            if (response)
                setCountries(response);
        });

        refDataService.loadStates().then((response) => {
            if (response)
                setStates(response);
        });

        if (id) {
            addressService.loadAddress(id).then(response => {
                if (response)
                    setAddress(response);
                else {
                    let errors = [];
                    errors.push('Something went wrong');
                    setErrorMessages(errors);
                }
            });
        }

    }, []);

    const setAddressState = (selectedStateId: string) => {
        let selectedStateName: string | null = null;
        let selectedStateAbbreviation: string | null = null;

        if (selectedStateId !== '') {
            let state = states.filter((state) => state.id === selectedStateId);
            selectedStateName = state[0].name;
            selectedStateAbbreviation = state[0].abbreviation;
        }
        setAddress({ ...address, stateName: selectedStateName, stateAbbreviation: selectedStateAbbreviation, stateId: (selectedStateId === '') ? null : selectedStateId })
    }

    const handleSave = () => {
        setErrorMessages([]);
        addressService.saveAddress(address).then((errors) => {
            if (errors && errors.length > 0) {
                setErrorMessages(errors);
            }
            else {
                navigate("/addresses");
            }
        });
    }

    const handleCancel = () => {
        navigate("/addresses");
    }

    return (
        <Container maxWidth="md">

            {(errorMessages && errorMessages.length > 0) && errorMessages.map(error => (
                <Alert severity="error">{error}</Alert>
            ))}
            {id ? <h4>Address: {id}</h4> : <h4>Add Address</h4>}
            {
                address &&
                <div className="container">
                    <div className="row mb-2">
                        <div className="col-6">
                            <TextField
                                id="StreetNumber"
                                label="Street Number"
                                fullWidth
                                value={streetNumber || ''}
                                inputProps={{
                                    maxLength: 50
                                }}
                                onChange={(e) => setAddress({ ...address, streetNumber: e.target.value })}
                            ></TextField>

                        </div>
                        <div className="col-6">
                            <TextField
                                id="StreetName"
                                label="Street Name"
                                fullWidth
                                value={streetName || ''}
                                inputProps={{
                                    maxLength: 50
                                }}
                                onChange={(e) => setAddress({ ...address, streetName: e.target.value })}
                            ></TextField>

                        </div>
                    </div>
                    <div className="row mb-2">
                        <div className="col-6">
                            <TextField
                                id="City"
                                label="City"
                                fullWidth
                                value={city || ''}
                                inputProps={{
                                    maxLength: 50
                                }}
                                onChange={(e) => setAddress({ ...address, city: e.target.value })}
                            ></TextField>
                        </div>
                        <div className="col-6">
                            <FormControl fullWidth>
                                <InputLabel id="stateIdlabel">State</InputLabel>
                                <Select
                                    labelId="stateIdlabel"
                                    id="stateId"
                                    value={stateId || ''}
                                    label="State"
                                    onChange={(e) => setAddressState(e.target.value)}
                                >
                                    <MenuItem value=""> </MenuItem>
                                    {states.map((option: StateModel) => (
                                        <MenuItem value={option.id}>{option.name}</MenuItem>
                                    ))}


                                </Select>
                            </FormControl>
                        </div>
                    </div>

                    <div className="row mb-2">
                        <div className="col-6">
                            <TextField
                                id="Zip"
                                label="Zip"
                                fullWidth
                                value={zipCode || ''}
                                inputProps={{
                                    maxLength: 5
                                }}
                                onChange={(e) => setAddress({ ...address, zipCode: e.target.value })}
                            ></TextField>
                        </div>
                    </div>





                    <div className="row mb-2">
                        <div className="col-12 text-right">
                            <Button className="mr-1" variant="contained" onClick={() => handleSave()}>Save</Button>
                            <Button variant="contained" color="error" onClick={() => handleCancel()}>Cancel</Button>
                        </div>
                    </div>
                </div>
            }

        </Container>

    );

}

export default AddressDetail;