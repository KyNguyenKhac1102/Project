import React from "react";
import "./Sidebar.css";
import { SidebarData } from "./SidebarData";
import { useHistory } from "react-router-dom";

export default function Sidebar() {
  const history = useHistory();

  return (
    <div className="Sidebar">
      <ul className="SidebarList">
        {SidebarData.map((val, key) => {
          return (
            <li
              id={window.location.pathname == val.link ? "active" : ""}
              className="row"
              key={key}
              onClick={() => {
                history.push(val.link);
                // window.location.href = val.link;
              }}
            >
              <div id="icon">{val.icon}</div>
              <div id="title">{val.title}</div>
            </li>
          );
        })}
      </ul>
    </div>
  );
}
