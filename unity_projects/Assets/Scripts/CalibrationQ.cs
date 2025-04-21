using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CalibrationQ", menuName = "Scriptable Objects/CalibrationQ")]
public class CalibrationQ : ScriptableObject
{
    public List<QuestionTemplate> questions;



}
