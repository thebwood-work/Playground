import axios from "axios";
import React, { FC, Fragment, useEffect, useState } from "react";
import { IPersonModel } from "../../app/models/interfaces/IPersonModel";
import { PeopleGrid } from "./components/peopleGrid";

const People: FC = () => {
    const [people, setPeople] = useState<IPersonModel[]>([])

    function LoadPeople(): void {
        axios.get<IPersonModel[]>('https://localhost:7243/api/people').then((response) => {
            if(response && response.data)
            {
                setPeople(response.data);
            }
        });
    }
    

    useEffect(() => {
        LoadPeople();
    }, [LoadPeople]);
    return(
        <Fragment>
            <div>
                <h1>People List</h1>
            </div>
            <div>
                <PeopleGrid rows={people}  />
            </div>  
        </Fragment>
    );
}
export default People;

