﻿using UnityEngine;
using System.Collections;

public interface Observer {

	void OnNotify(GameEvent e);

}