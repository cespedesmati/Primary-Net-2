import { Divider, List, ListItem, ListSubheader } from "@mui/material"
import { SidebarOption } from "./SidebarOption"
import { getSession, useSession } from "next-auth/react"



const options = [
  // {
  //   name: "Home",
  //   path: "/user/"
  // },
  {
    name: "Catalogue",
    path: "/catalogue"
  },
  {
    name: "Transactions",
    path: "/transactions"
  },
  {
    name: "Fixed Term Deposits",
    path: "/fixed"
  },
  {
    name: "Transfer",
    path: "/"
  },
  {
    name: "Topup",
    path: "account/deposit"
  },

]


export const entities = [
  {
    name: "Accounts",
    path: "/admin/accounts",
  },
  {
    name: "Catalogues",
    path: "/admin/catalogues",
  },
  // {
  //   name: "Fixed Term Deposits",
  //   path: "/admin/fixed",
  // },
  {
    name: "Roles",
    path: "/admin/roles",
  },
  {
    name: "Transactions",
    path: "/admin/transactions",
  },
  {
    name: "Users",
    path: "/admin/users",
  },
]

export const SideBarList = ({ session }) => {

  const userRole = session?.user?.rol;

  return (
    <List>
      {
        options.map(({ name, path }) => (
          <SidebarOption key={name} name={name} path={path} />
        ))
      }
      {
        userRole !== "Admin"
          ? null
          :
          <>
            <Divider sx={{ pt: 2 }} />
            <ListSubheader>
              Admin Panel
            </ListSubheader>
            {
              entities.map(({ name, path }) => (
                <SidebarOption key={name} name={name} path={path} />

              ))
            }
          </>
      }
    </List>
  )
}
