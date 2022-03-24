import { Button, Container, TextField } from "@mui/material";
import React from "react";
import { AddressSearchModel } from "../../../app/models/addresses/AddressSearchModel";
import { IAddressSearchModel } from "../../../app/models/addresses/interfaces/IAddressSearchModel";

interface ChildProps {
    HandleSearch: (addressSearch: IAddressSearchModel) => void;
}

const AddressSearchForm: React.FC<ChildProps> = (props) => {
    const [addressSearch, setAddressSearch] = React.useState<IAddressSearchModel>(new AddressSearchModel());
    const { HandleSearch } = props;
    const { streetNumber, streetName, city, stateId } = addressSearch;

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