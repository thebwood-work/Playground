import { Button, Container, TextField } from "@mui/material";
import React from "react";
import { IPersonSearchModel } from "../../../app/models/people/interfaces/IPersonSearchModel";
import { PersonSearchModel } from "../../../app/models/people/PersonSearchModel";

interface ChildProps {
    HandleSearch: (personSearch: IPersonSearchModel) => void;
}

const PersonSearchForm: React.FC<ChildProps> = (props) => {
    const [personSearch, setPersonSearch] = React.useState<IPersonSearchModel>(new PersonSearchModel());
    const { HandleSearch } = props;
    const { firstName, lastName } = personSearch;

    return (
        <Container>
            <div className="row mb-2">
                <div className="col-6">
                    <TextField
                        id="FirstName"
                        label="First Name"
                        fullWidth
                        value={firstName || ''}
                        inputProps={{
                            maxLength: 50
                        }}
                        onChange={(e) => setPersonSearch({ ...personSearch, firstName: e.target.value })}
                    ></TextField>

                </div>
                <div className="col-6">
                    <TextField
                        id="LastName"
                        label="Last Name"
                        fullWidth
                        value={lastName || ''}
                        inputProps={{
                            maxLength: 50
                        }}
                        onChange={(e) => setPersonSearch({ ...personSearch, lastName: e.target.value })}
                    ></TextField>

                </div>

            </div>
            <div className="row mb-2">
                <div className="col-12">
                    <Button className="float-right" variant="contained" onClick={() => HandleSearch(personSearch)}>Search</Button>
                </div>
            </div>
        </Container>
    );
}

export default PersonSearchForm;