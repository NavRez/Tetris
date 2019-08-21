Imports Microsoft.VisualBasic.Devices
'Author : Navid Reza
Public Class MusicList
    Inherits Audio


    Sub Main()
        MsgBox("The Main procedure is starting the application.")
        ' Insert call to appropriate starting place in your code.  
        MsgBox("The application is terminating.")
    End Sub


    Sub PlayMusicBackground()
        My.Computer.Audio.Play("G:\Tetris_theme.wav", AudioPlayMode.BackgroundLoop) ' Allows computer to dig in playable wav. from specified location and loop it through

    End Sub

    Sub EndMusic()
        My.Computer.Audio.Stop() ' stops the wave

    End Sub


End Class

