﻿Public Class Form1
    Private bsCustomers As New BindingSource
    Private Sub Form1_Shown(sender As Object, e As EventArgs) _
    Handles Me.Shown

        Dim ops As New DatabaseOperations

        If ops.IsSuccessFul Then
            bsCustomers.DataSource = ops.LoadCustomers
            DataGridView1.DataSource = bsCustomers
            BindingNavigator1.BindingSource = bsCustomers
        Else
            MessageBox.Show(ops.LastExceptionMessage)
        End If

    End Sub
    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) _
        Handles BindingNavigatorDeleteItem.Click

        If My.Dialogs.Question($"Remove '{bsCustomers.CurrentRow().Field(Of String)("CompanyName")}'?") Then
            Dim ops As New DatabaseOperations
            ops.RemoveCustomer(bsCustomers.CurrentRow().Field(Of Integer)("Identifier"))
        End If
    End Sub
End Class