Public Class Form1

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim NoOfCars As Double
        Dim MemCar_VeryFew As Double
        Dim MemCar_few As Double
        Dim MemCar_Normal As Double
        Dim MemCar_High As Double

        Dim TimeOfWaiting As Double
        Dim MemTimeW_verylow As Double
        Dim MemTimeW_low As Double
        Dim MemTimeW_Normal As Double
        Dim MemTimeW_High As Double

        Dim TimeToAllocate As Integer
        Dim MTimeAllocate_verylow As Double
        Dim MTimeAllocate_low As Double
        Dim MTimeAllocate_Normal As Double
        Dim MTimeAllocate_High As Double

        NoOfCars = TextBox1.Text
        TimeOfWaiting = TextBox2.Text

        If NoOfCars > 0 And NoOfCars <= 5 Then
            MemCar_VeryFew = -0.2 * NoOfCars + 1
            MemCar_few = 0.2 * NoOfCars
            If TimeOfWaiting >= 0 And TimeOfWaiting <= 40 Then

                MemTimeW_verylow = (-0.025 * TimeOfWaiting) + 1
                MemTimeW_low = 0.025 * TimeOfWaiting

                'Compare all the Membership value to get membership value of timetoallocate
                If MemCar_VeryFew <> 0 And MemTimeW_verylow <> 0 Then
                    MTimeAllocate_verylow = Math.Min(MemTimeW_verylow, MemCar_VeryFew)

                End If
                If MemCar_VeryFew <> 0 And MemTimeW_low <> 0 Then
                    If MTimeAllocate_verylow < Math.Min(MemTimeW_low, MemCar_VeryFew) Then
                        MTimeAllocate_verylow = Math.Min(MemTimeW_low, MemCar_VeryFew)
                    End If
                End If
                If MemCar_few <> 0 And MemTimeW_verylow <> 0 Then
                    MTimeAllocate_low = Math.Min(MemCar_few, MemTimeW_verylow)

                End If
                If MemCar_few <> 0 And MemTimeW_low <> 0 Then
                    If MTimeAllocate_low < Math.Min(MemCar_few, MemTimeW_low) Then
                        MTimeAllocate_low = Math.Min(MemCar_few, MemTimeW_low)
                    End If


                End If
                TimeToAllocate = (((MTimeAllocate_verylow - 1) / -0.025) + (MTimeAllocate_low / 0.025) + ((MTimeAllocate_low - 2) / -0.025)) / 3
                Label3.Text = TimeToAllocate.ToString
            ElseIf TimeOfWaiting >= 41 And TimeOfWaiting <= 80 Then
                MemTimeW_low = -0.025 * TimeOfWaiting + 2
                MemTimeW_Normal = 0.025 * TimeOfWaiting - 1

                If MemCar_VeryFew <> 0 And MemTimeW_low <> 0 Then
                    MTimeAllocate_verylow = Math.Min(MemCar_VeryFew, MemTimeW_low)
                End If

                If MemCar_VeryFew <> 0 And MemTimeW_Normal <> 0 Then
                    MTimeAllocate_low = Math.Min(MemCar_VeryFew, MemTimeW_Normal)
                End If

                If MemCar_few <> 0 And MemTimeW_low <> 0 Then
                    If MTimeAllocate_low < Math.Min(MemCar_few, MemTimeW_low) Then
                        MTimeAllocate_low = Math.Min(MemCar_few, MemTimeW_low)
                    End If
                End If
                If MemCar_few <> 0 And MemTimeW_Normal <> 0 Then
                    If MTimeAllocate_low < Math.Min(MemCar_few, MemTimeW_Normal) Then
                        MTimeAllocate_low = Math.Min(MemCar_few, MemTimeW_Normal)
                    End If
                End If
                TimeToAllocate = (((MTimeAllocate_verylow - 1) / -0.025) + (MTimeAllocate_low / 0.025) + ((MTimeAllocate_low - 2) / -0.025)) / 3
                Label3.Text = TimeToAllocate.ToString
            ElseIf TimeOfWaiting >= 81 And TimeOfWaiting <= 120 Then
                MemTimeW_Normal = -0.025 * TimeOfWaiting + 3
                MemTimeW_High = 0.025 * TimeOfWaiting - 2

                If MemCar_VeryFew <> 0 And MemTimeW_Normal <> 0 Then
                    MTimeAllocate_low = Math.Min(MemCar_VeryFew, MemTimeW_Normal)
                End If
                If MemCar_VeryFew <> 0 And MemTimeW_High <> 0 Then
                    If MTimeAllocate_low < Math.Min(MemCar_VeryFew, MemTimeW_High) Then
                        MTimeAllocate_low = Math.Min(MemCar_VeryFew, MemTimeW_High)
                    End If
                End If
                If MemCar_few <> 0 And MemTimeW_Normal <> 0 Then
                    If MTimeAllocate_low < Math.Min(MemCar_few, MemTimeW_Normal) Then
                        MTimeAllocate_low = Math.Min(MemCar_few, MemTimeW_Normal)
                    End If
                End If
                If MemCar_few <> 0 And MemTimeW_High <> 0 Then
                    MTimeAllocate_Normal = Math.Min(MemCar_few, MemTimeW_High)
                End If
                TimeToAllocate = (((MTimeAllocate_verylow - 1) / -0.025) + (MTimeAllocate_low / 0.025) + ((MTimeAllocate_low - 2) / -0.025) + ((MTimeAllocate_Normal + 1) / 0.025) + ((MTimeAllocate_Normal - 3) / -0.025)) / 5
                'TimeToAllocate = (-(((MTimeAllocate_verylow - 1) / 0.025) * (MTimeAllocate_verylow)) + ((-(MTimeAllocate_low - 2) / 0.025) * (MTimeAllocate_low)) + ((MTimeAllocate_low / 0.025) * MTimeAllocate_low) + (((MTimeAllocate_Normal + 1) / 0.025) * (MTimeAllocate_Normal)) + ((-(MTimeAllocate_Normal - 3) / 0.025)) * (MTimeAllocate_Normal)) / (MTimeAllocate_verylow + MTimeAllocate_low + MTimeAllocate_Normal)
                Label3.Text = TimeToAllocate.ToString
            ElseIf TimeOfWaiting > 120 Then
                Label3.Text = "invalid Time of waiting"
            End If

        ElseIf NoOfCars >= 6 And NoOfCars <= 10 Then
            MemCar_few = -0.2 * NoOfCars + 2
            MemCar_Normal = 0.2 * NoOfCars - 1
            'Start here
            If TimeOfWaiting >= 0 And TimeOfWaiting <= 40 Then
                MemTimeW_verylow = (-0.025 * TimeOfWaiting) + 1
                MemTimeW_low = 0.025 * TimeOfWaiting
                If MemCar_few <> 0 And MemTimeW_verylow <> 0 Then
                    MTimeAllocate_verylow = Math.Min(MemCar_few, MemTimeW_verylow)
                End If
                If MemCar_few <> 0 And MemTimeW_low <> 0 Then
                    MTimeAllocate_low = Math.Min(MemCar_few, MemTimeW_low)
                End If
                If MemCar_Normal <> 0 And MemTimeW_verylow <> 0 Then
                    If MTimeAllocate_low < Math.Min(MemCar_Normal, MemTimeW_verylow) Then
                        MTimeAllocate_low = Math.Min(MemCar_Normal, MemTimeW_verylow)
                    End If
                    If MemCar_Normal <> 0 And MemTimeW_low <> 0 Then
                        If MTimeAllocate_low < Math.Min(MemCar_Normal, MemTimeW_low) Then
                            MTimeAllocate_low = Math.Min(MemCar_Normal, MemTimeW_low)
                        End If
                    End If
                End If
                TimeToAllocate = (((MTimeAllocate_verylow - 1) / -0.025) + (MTimeAllocate_low / 0.025) + ((MTimeAllocate_low - 2) / -0.025)) / 3
                Label3.Text = TimeToAllocate.ToString
            ElseIf TimeOfWaiting >= 41 And TimeOfWaiting <= 80 Then
                MemTimeW_low = -0.025 * TimeOfWaiting + 2
                MemTimeW_Normal = 0.025 * TimeOfWaiting - 1
                If MemCar_few <> 0 And MemTimeW_low <> 0 Then
                    MTimeAllocate_low = Math.Min(MemCar_few, MemTimeW_low)
                End If
                If MemCar_few <> 0 And MemTimeW_Normal <> 0 Then
                    If MTimeAllocate_low < Math.Min(MemCar_few, MemTimeW_Normal) Then
                        MTimeAllocate_low = Math.Min(MemCar_few, MemTimeW_Normal)
                    End If
                    If MemCar_Normal <> 0 And MemTimeW_low <> 0 Then
                        If MTimeAllocate_low < Math.Min(MemCar_Normal, MemTimeW_low) Then
                            MTimeAllocate_low = Math.Min(MemCar_Normal, MemTimeW_low)
                        End If
                        If MemCar_Normal <> 0 And MemTimeW_Normal <> 0 Then
                            MTimeAllocate_Normal = Math.Min(MemCar_Normal, MemTimeW_Normal)
                        End If
                    End If
                    TimeToAllocate = ((MTimeAllocate_low / 0.025) + ((MTimeAllocate_low - 2) / -0.025) + ((MTimeAllocate_Normal + 1) / 0.025) + ((MTimeAllocate_Normal - 3) / -0.025)) / 4
                    Label3.Text = TimeToAllocate.ToString
                End If
            ElseIf TimeOfWaiting >= 81 And TimeOfWaiting <= 120 Then
                MemTimeW_Normal = -0.025 * TimeOfWaiting + 3
                MemTimeW_High = 0.025 * TimeOfWaiting - 2
                If MemCar_few <> 0 And MemTimeW_Normal <> 0 Then
                    MTimeAllocate_low = Math.Min(MemCar_few, MemTimeW_Normal)
                End If
                If MemCar_few <> 0 And MemTimeW_High <> 0 Then
                    MTimeAllocate_Normal = Math.Min(MemCar_few, MemTimeW_High)
                End If
                If MemCar_Normal <> 0 And MemTimeW_Normal <> 0 Then
                    If MTimeAllocate_Normal < Math.Min(MemCar_Normal, MemTimeW_Normal) Then
                        MTimeAllocate_Normal = Math.Min(MemCar_Normal, MemTimeW_Normal)
                    End If

                End If
                If MemCar_Normal <> 0 And MemTimeW_High <> 0 Then
                    If MTimeAllocate_Normal < Math.Min(MemCar_Normal, MemTimeW_High) Then
                        MTimeAllocate_Normal = Math.Min(MemCar_Normal, MemTimeW_High)
                    End If
                End If
                TimeToAllocate = ((MTimeAllocate_low / 0.025) + ((MTimeAllocate_low - 2) / -0.025) + ((MTimeAllocate_Normal + 1) / 0.025) + ((MTimeAllocate_Normal - 3) / -0.025)) / 4
                Label3.Text = TimeToAllocate.ToString
            End If
        ElseIf NoOfCars >= 11 And NoOfCars <= 15 Then
            MemCar_Normal = -0.2 * NoOfCars + 3
            MemCar_High = 0.2 * NoOfCars - 2
            'stsrt here
            If TimeOfWaiting >= 0 And TimeOfWaiting <= 40 Then
                MemTimeW_verylow = (-0.025 * TimeOfWaiting) + 1
                MemTimeW_low = 0.025 * TimeOfWaiting
                If MemCar_Normal <> 0 And MemTimeW_verylow <> 0 Then
                    MTimeAllocate_low = Math.Min(MemCar_Normal, MemTimeW_verylow)
                End If
                If MemCar_Normal <> 0 And MemTimeW_low <> 0 Then
                    If MTimeAllocate_low < Math.Min(MemCar_Normal, MemTimeW_low) Then
                        MTimeAllocate_low = Math.Min(MemCar_Normal, MemTimeW_low)
                    End If
                End If
                If MemCar_High <> 0 And MemTimeW_verylow <> 0 Then
                    MTimeAllocate_Normal = Math.Min(MemCar_High, MemTimeW_verylow)
                End If
                If MemCar_High <> 0 And MemTimeW_low <> 0 Then
                    If MTimeAllocate_Normal < Math.Min(MemCar_High, MemTimeW_low) Then
                        MTimeAllocate_Normal = Math.Min(MemCar_High, MemTimeW_low)
                    End If
                End If
                TimeToAllocate = ((MTimeAllocate_low / 0.025) + ((MTimeAllocate_low - 2) / -0.025) + ((MTimeAllocate_Normal + 1) / 0.025) + ((MTimeAllocate_Normal - 3) / -0.025)) / 4
                Label3.Text = TimeToAllocate.ToString

            ElseIf TimeOfWaiting >= 41 And TimeOfWaiting <= 80 Then
                MemTimeW_low = -0.025 * TimeOfWaiting + 2
                MemTimeW_Normal = 0.025 * TimeOfWaiting - 1
                If MemCar_Normal <> 0 And MemTimeW_low <> 0 Then
                    MTimeAllocate_low = Math.Min(MemCar_Normal, MemTimeW_low)
                End If
                If MemCar_Normal <> 0 And MemTimeW_Normal <> 0 Then
                    MTimeAllocate_Normal = Math.Min(MemCar_Normal, MemTimeW_Normal)
                End If
                If MemCar_High <> 0 And MemTimeW_low <> 0 Then
                    If MTimeAllocate_Normal < Math.Min(MemCar_High, MemTimeW_low) Then
                        MTimeAllocate_Normal = Math.Min(MemCar_High, MemTimeW_low)
                    End If
                End If
                If MemCar_High <> 0 And MemTimeW_Normal Then
                    If MTimeAllocate_Normal < Math.Min(MemCar_High, MemTimeW_Normal) Then
                        MTimeAllocate_Normal = Math.Min(MemCar_High, MemTimeW_Normal)
                    End If
                End If
                TimeToAllocate = ((MTimeAllocate_low / 0.025) + ((MTimeAllocate_low - 2) / -0.025) + ((MTimeAllocate_Normal + 1) / 0.025) + ((MTimeAllocate_Normal - 3) / -0.025)) / 4
                Label3.Text = TimeToAllocate.ToString
            ElseIf TimeOfWaiting >= 81 And TimeOfWaiting <= 120 Then
                MemTimeW_Normal = -0.025 * TimeOfWaiting + 3
                MemTimeW_High = 0.025 * TimeOfWaiting - 2
                'MessageBox.Show(MemCar_Normal.ToString)
                If MemCar_Normal <> 0 And MemTimeW_Normal <> 0 Then
                    MTimeAllocate_Normal = Math.Min(MemCar_Normal, MemTimeW_Normal)
                    'MessageBox.Show(MemTimeW_Normal.ToString)
                End If
                If MemCar_Normal <> 0 And MemTimeW_High <> 0 Then
                    If MTimeAllocate_Normal < Math.Min(MemCar_Normal, MemTimeW_High) Then
                        MTimeAllocate_Normal = Math.Min(MemCar_Normal, MemTimeW_High)
                    End If
                End If
                If MemCar_High <> 0 And MemTimeW_Normal <> 0 Then
                    If MTimeAllocate_Normal < Math.Min(MemCar_Normal, MemTimeW_Normal) Then
                        MTimeAllocate_Normal = Math.Min(MemCar_Normal, MemTimeW_Normal)
                    End If
                End If
                If MemCar_High <> 0 And MemTimeW_High <> 0 Then
                    MTimeAllocate_High = Math.Min(MemCar_High, MemTimeW_High)
                End If
                TimeToAllocate = (((MTimeAllocate_Normal + 1) / 0.025) + ((MTimeAllocate_Normal - 3) / -0.025) + ((MTimeAllocate_High + 2) / 0.025)) / 3

                Label3.Text = TimeToAllocate.ToString
            End If


        ElseIf NoOfCars = 0 Then
            TimeToAllocate = 0
            Label3.Text = TimeToAllocate.ToString
        End If




    End Sub
End Class
