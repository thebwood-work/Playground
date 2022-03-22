import axios from "axios";
import React, { FC, Fragment, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { IPersonModel } from "../../app/models/people/interfaces/IPersonModel";
import { IPersonSearchModel } from "../../app/models/people/interfaces/IPersonSearchModel";
import { PersonSearchModel } from "../../app/models/people/PersonSearchModel";
import { PeopleGrid } from "./components/peopleGrid";
import PersonSearchForm from "./components/personSearchForm";

const People: FC = () => {
    const navigate = useNavigate();
    const [people, setPeople] = useState<IPersonModel[]>([]);
    const [rowId, setRowId] = useState<string | null>(null);
    const [searchForm, setSearchForm] = React.useState<IPersonSearchModel>(new PersonSearchModel());

    const searchPeople = (personSearchFields: IPersonSearchModel): void => {
        axios.post<IPersonModel[]>('https://localhost:5010/people/search', personSearchFields).then((response) => {
            if(response && response.data)
            {
                setSearchForm(personSearchFields);
                setPeople(response.data);
            }
        });
    }


    const deletePerson = (rowId: string | null): void => {
        if(rowId && window.confirm('Are you sure you want to delete this person?')) {
            axios.delete<Boolean>('https://localhost:5010/people/' + rowId).then((response) => {
                if(response && response.data)
                {
                    searchPeople(searchForm);
                }
            });
        }
    }

    useEffect(() => {
        searchPeople(searchForm);
    }, []);

    return(
        <Fragment>
            <div>
                <h1>People List</h1>
            </div>
            <div>
                <PersonSearchForm HandleSearch={searchPeople} />
            </div>
            <div>
                <PeopleGrid rows={people} handleDeleteClick={deletePerson} />
            </div>  
        </Fragment>
    );
}
export default People;

