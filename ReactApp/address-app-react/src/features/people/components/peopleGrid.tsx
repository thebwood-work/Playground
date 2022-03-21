import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableFooter from '@mui/material/TableFooter';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { IPersonModel } from '../../../app/models/people/interfaces/IPersonModel';
import TablePaging from '../../../app/components/tablePaging/tablePaging';
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import { useNavigate } from 'react-router-dom';
import { Button, TableHead } from '@mui/material';
import moment from 'moment';


export interface PeopleGridProps {
  rows: IPersonModel[]
}


export const PeopleGrid = (props: PeopleGridProps) => {
  const navigate = useNavigate();
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(5);

  // Avoid a layout jump when reaching the last page with empty rows.
  const emptyRows =
    page > 0 ? Math.max(0, (1 + page) * rowsPerPage - props.rows.length) : 0;

  const handleChangePage = (
    event: React.MouseEvent<HTMLButtonElement> | null,
    newPage: number,
  ) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };


  const handleEditClick = (rowId: string | null) => {
    if (rowId)
      navigate("/people/" + rowId);
  }
  const handleAddClick = () => {
    navigate("/people/add");
  }

  return (
    <div>
      <div className="row mb-2 ">
        <div className="col-4 text-right">
        <Button variant="outlined" startIcon={<AddIcon />} onClick={() => { handleAddClick(); }} color="success">
          Add
        </Button>
        </div>
      </div>
      <div className="row">
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 500 }} aria-label="custom pagination table">
            <TableHead className="bg-primary">
              <TableRow>
                <TableCell className="text-white" align="center">Edit</TableCell>
                <TableCell className="text-white" align="right">First Name</TableCell>
                <TableCell className="text-white" align="right">Last Name</TableCell>
                <TableCell className="text-white" align="right">Date of Birth</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {(rowsPerPage > 0
                ? props.rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                : props.rows
              ).map((row) => (
                <TableRow key={row.id}>
                  <TableCell style={{ width: 40 }} align="center">
                    <Button variant="outlined" startIcon={<EditIcon />} onClick={() => { handleEditClick(row.id); }}>
                      Edit
                    </Button>
                  </TableCell>
                  <TableCell style={{ width: 160 }} align="right">
                    {row.firstName}
                  </TableCell>
                  <TableCell style={{ width: 160 }} align="right">
                    {row.lastName}
                  </TableCell>

                  <TableCell style={{ width: 160 }} align="right">
                    {row.dateOfBirth ? moment(row.dateOfBirth).format("YYYY-MM-DD") : ""}
                  </TableCell>
                </TableRow>
              ))}
              {emptyRows > 0 && (
                <TableRow style={{ height: 53 * emptyRows }}>
                  <TableCell colSpan={6} />
                </TableRow>
              )}
            </TableBody>
            <TableFooter>
              <TableRow>
                <TablePagination
                  rowsPerPageOptions={[5, 10, 25, { label: 'All', value: -1 }]}
                  colSpan={3}
                  count={props.rows.length}
                  rowsPerPage={rowsPerPage}
                  page={page}
                  SelectProps={{
                    inputProps: {
                      'aria-label': 'rows per page',
                    },
                    native: true,
                  }}
                  onPageChange={handleChangePage}
                  onRowsPerPageChange={handleChangeRowsPerPage}
                  ActionsComponent={TablePaging}
                />
              </TableRow>
            </TableFooter>
          </Table>
        </TableContainer>
      </div>
    </div>
  );
}