import React, { useEffect, useState } from "react";
import { DataGrid } from "@mui/x-data-grid";
import axios from "axios";
import { useHistory } from "react-router-dom";
import { Button } from "@mui/material";

export default function UserTable() {
  const [userData, setUserData] = useState([]);
  const history = useHistory();

  const serverDelete = (delete_id) => {
    axios
      .delete(`/api/User?id=${delete_id}`, {
        id: delete_id,
      })
      .then((res) => {
        console.log(res);
        getServerData();
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const getServerData = () => {
    axios
      .get("/api/User")
      .then((res) => {
        setUserData(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const columns = [
    { field: "id", headerName: "ID", width: 100 },
    { field: "name", headerName: "UserName", width: 200 },
    { field: "phoneNumber", headerName: "Phone Number", width: 200 },

    { field: "create_At", headerName: "Create At", width: 230 },
    { field: "update_At", headerName: "Update At", width: 230 },
    {
      field: "edit",
      headerName: "",
      width: 100,
      sortable: false,
      renderCell: (params) => {
        const handleClick = (e) => {
          e.stopPropagation();

          const api = params.api;

          const thisRow = {};
          api
            .getAllColumns()
            .filter((c) => c.field !== "__check__" && !!c)
            .forEach(
              (c) => (thisRow[c.field] = params.getValue(params.id, c.field))
            );
          history.push(`/user/edit/${thisRow.id}`);
        };
        return (
          <Button variant="contained" onClick={handleClick}>
            Edit
          </Button>
        );
      },
    },
    {
      field: "delete",
      headerName: "",
      width: 100,
      sortable: false,
      renderCell: (params) => {
        const handleClick = (e) => {
          e.stopPropagation();
          const api = params.api;

          const thisRow = {};
          api
            .getAllColumns()
            .filter((c) => c.field !== "__check__" && !!c)
            .forEach(
              (c) => (thisRow[c.field] = params.getValue(params.id, c.field))
            );
          serverDelete(thisRow.id);
          // getServerData();
        };
        return (
          <Button variant="contained" color="error" onClick={handleClick}>
            Delete
          </Button>
        );
      },
    },
  ];

  useEffect(() => {
    getServerData();
  }, []);

  return (
    <div style={{ height: 400, width: "100%", margin: 20 }}>
      <DataGrid
        rows={userData}
        columns={columns}
        pageSize={5}
        rowsPerPageOptions={[5]}
        checkboxSelection
      />
      <Button
        style={{ margin: 10 }}
        variant="contained"
        onClick={() => {
          history.push("/user/create");
        }}
      >
        Create
      </Button>
    </div>
  );
}
