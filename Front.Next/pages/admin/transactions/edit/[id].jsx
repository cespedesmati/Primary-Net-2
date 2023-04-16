import { ConfirmSweetAlert } from "@/components/alerts/ConfirmSweetAlert";
import { SweetAlert } from "@/components/alerts/SweetAlert";
import { Layout } from "@/layouts/Layout";
import { Box, Button, FormControlLabel, Grid, Switch, TextField, Typography } from "@mui/material";
import axios from "axios";
import { getSession, useSession } from "next-auth/react";
import Head from "next/head";
import { useRouter } from "next/router";
import { useState } from "react";

const UpdateTransactionsForm = ({ transaction }) => {
  const router = useRouter();
  const { id } = router.query;

  const [concept, setConcept] = useState(transaction?.concept);
  const [showConfirm, setShowConfirm] = useState(false);
  const [showSuccess, setShowSuccess] = useState(false);
  const [showError, setShowError] = useState(false);

  const { data: session } = useSession();

  const handleConceptChange = (event) => {
    setConcept(event.target.value);
  };

  const handleSubmit = async () => {
    try {
      if (transaction.type === "repayment") {
        throw new Error("This transaction has already been reversed");
      }

      const { data, status } = await axios.put(
        `https://localhost:7149/api/Transactions/${id}`,
        {
          concept,
        },
        {
          headers: {
            Authorization: `Bearer ${session.user?.token}`,
            "Content-Type": "application/json",
          },
        }
      );

      if (status == 200) {
        setShowSuccess(true);
        router.push("/admin/transactions");
      }
    } catch (error) {
      setShowError(true);
      console.log(error);
    }
  };

    return (
        <>
        <Head>
            <title>Primates - Admin transaction update</title>
        </Head>
            {
                showConfirm && <ConfirmSweetAlert
                    title='Confirmation'
                    text={`Are you sure you want to update the transaction ${id}?`}
                    confirmButtonText='Yes'
                    cancelButtonText='No'
                    onConfirm={handleSubmit}
                    onCancel={() => setShowConfirm(false)}
                    onClose={() => setShowConfirm(false)}
                />
            }
            {
                showSuccess && <SweetAlert
                    title='Success!'
                    text='The transaction has been updated successfully.'
                    icon= 'success'
                    timer= {3000}
                    onClose={() => setShowSuccess(false)}
                />
            }
            {
                showError && <SweetAlert
                    title= 'Error!'
                    text= 'There was an error updating the transaction.'
                    icon= 'error'
                    timer= {3000}
                    onClose={() => setShowError(false)}
                 />
            }
            <Layout>
                <Grid container sx={{ display: 'flex', alignItems: 'center', justifyContent: 'center', mt: 4 }}>

                    <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', p: 4, bgcolor: '#F5F5F5', borderRadius: 5, boxShadow: '0px 0px 10px rgba(0, 0, 0, 0.2)', width: '800px' }}>
                        <Typography variant="h3" component="h2" gutterBottom>
                            Update transaction {id}
                        </Typography>
                        <form onSubmit={(event) => {
                            event.preventDefault();
                            setShowConfirm(true);
                            }}>

                            <Box sx={{ display: 'flex', flexDirection: 'column', width: '100%', maxWidth: 500, mt: 2 }}>
                                <Box sx={{ display: 'flex', flexDirection: 'column', mb: 2 }}>
                                </Box>
                                <TextField
                                    sx={{ mb: 2 }}
                                    label={"New concept"}
                                    type="string"
                                    value={concept}
                                    onChange={handleConceptChange}
                                />
                                
                                </Box>
                                <Button
                                    sx={{ mt: 3, alignSelf: 'center' }}
                                    variant="contained"
                                    color="primary"
                                    type="submit"
                                >
                                    Update transaction
                                </Button>
                        </form>
                    </Box>
                </Grid>
            </Layout>
        </>
    );
}

export const getServerSideProps = async (context) => {

    try {
        const session = await getSession(context);

        const now = Math.floor(Date.now() / 1000);

        if (session == null || session.expires < now) {
            return {
                redirect: {
                    destination: '/login',
                    permanent: false,
                },
            };
        }

        if (session.user.rol != 'Admin') {
            return {
                redirect: {
                    destination: '/?invalidcredentials=true',
                    permanent: false,
                },
            };
        }


        const { id } = context.params;
        const { data } = await axios.get(`https://localhost:7149/api/Transactions/${id}`, {
  headers: {
    'Authorization': `Bearer ${session.user?.token}`,
    "Content-Type": "application/json",
  }
});

if (data.type === "repayment") {
  setIsReversed(true);
  return {
    props: {
      transaction: null
    }
  };
}

return {
  props: {
    transaction: data,
  }
};

}catch (error) {
        setShowError(true);
        console.log(error);
      }
      
}


export default UpdateTransactionsForm;