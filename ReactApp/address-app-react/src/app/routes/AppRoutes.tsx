import { FC } from "react";
import { Route, Routes } from "react-router-dom";
import Addresses from "../../features/addresses";
import AddressDetail from "../../features/addresses/detail";
import Dashboard from "../../features/dashboard";
import NotFound from "../../features/errors/NotFound";
import People from "../../features/people";
import PersonDetail from "../../features/people/detail";



const AppRoutes: FC = () => {
    return <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="people/add" element={<PersonDetail />} />
        <Route path="people/:id" element={<PersonDetail />} />
        <Route path="people" element={<People />} />
        <Route path="addresses/add" element={<AddressDetail />} />
        <Route path="addresses/:id" element={<AddressDetail />} />
        <Route path="addresses" element={<Addresses />} />
        <Route path="*" element={<NotFound />} />
    </Routes>;
}
export default AppRoutes;

