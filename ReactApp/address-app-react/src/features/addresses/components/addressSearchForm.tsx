import { Button, Container, FormControl, InputLabel, Menu, MenuItem, Select, TextField } from "@mui/material";
import React from "react";
import { AddressSearchModel } from "../../../app/models/addresses/AddressSearchModel";
import { IAddressSearchModel } from "../../../app/models/addresses/interfaces/IAddressSearchModel";
import { CountryModel } from "../../../app/models/refData/CountryModel";
import { StateModel } from "../../../app/models/refData/StateModel";

interface ChildProps {
    HandleSearch: (addressSearch: IAddressSearchModel) => void;
    States: StateModel[];
    Countries: CountryModel[];
}

const AddressSearchForm: React.FC<ChildProps> = (props) => {
    const [addressSearch, setAddressSearch] = React.useState<IAddressSearchModel>(new AddressSearchModel());
    const { HandleSearch } = props;
    const { streetNumber, streetName, city, stateId, zipCode } = addressSearch;

    return (
        <Container>
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
                        onChange={(e) => setAddressSearch({ ...addressSearch, streetNumber: e.target.value })}
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
                        onChange={(e) => setAddressSearch({ ...addressSearch, streetName: e.target.value })}
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
                        onChange={(e) => setAddressSearch({ ...addressSearch, city: e.target.value })}
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
                            onChange={(e) => setAddressSearch({ ...addressSearch, stateId: (e.target.value === '' ) ? null : e.target.value })}
                        >
                            <MenuItem value=""> </MenuItem>
                            {props.States.map((option: StateModel) => (
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
                                onChange={(e) => setAddressSearch({ ...addressSearch, zipCode: e.target.value })}
                            ></TextField>
                        </div>
                    </div>            
            <div className="row mb-2">
                <div className="col-12">
                    <Button className="float-right" variant="contained" onClick={() => HandleSearch(addressSearch)}>Search</Button>
                </div>
            </div>
        </Container>
    );
}

export default AddressSearchForm;